DROP TABLE IF EXISTS logging;
DROP TABLE IF EXISTS organizations_contracts;
DROP TABLE IF EXISTS vaccination;
DROP TABLE IF EXISTS contract;
DROP TABLE IF EXISTS animal;
DROP TABLE IF EXISTS animal_category;
DROP TABLE IF EXISTS towns_service;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS organization;
DROP TABLE IF EXISTS statistic_town;
DROP TABLE IF EXISTS statistics;
DROP TABLE IF EXISTS town;
DROP TABLE IF EXISTS permission_role;
DROP TABLE IF EXISTS permission;
DROP TABLE IF EXISTS role;
DROp TABLE IF EXISTS statistic_town;
DROP TABLE IF EXISTS town;
DROP TABLE IF EXISTS status_statistic;

DROP TABLE IF EXISTS logging;
DROP TABLE IF EXISTS animal_status;

CREATE TABLE role (
    id serial primary key,
    name varchar(100)
);

CREATE TABLE town (
    id serial primary key,
    name varchar(100)
);

CREATE TABLE organization (
    id serial primary key,
    full_name varchar(100),
    inn char(10),
    kpp char(8),
    address varchar(100),
    type varchar(100),
    legal_entity bool,
    fk_town int not null,
    foreign key (fk_town) references town (id)
);

CREATE TABLE users (
    id serial primary key,
    login varchar(100),
    password varchar(100),
    fk_org int not null,
    fk_role int not null,
    surname VARCHAR(255),
    name VARCHAR(255),
    patronymic VARCHAR(255),
    phone VARCHAR(20),
    email VARCHAR(255),
    work_phone varchar(255),
    work_email varchar(255),
    foreign key (fk_role) references role (id),
    foreign key (fk_org) references organization (id)
);

CREATE TABLE animal_category (
    id serial primary key,
    name varchar(155) not null 
);

CREATE  TABLE animal_status (
    id serial primary key,
    status varchar(100)
);

CREATE TABLE animal (
    id serial primary key,
    reg_num int8,
    sex bool,
    year_birth date,
    electronic_chip_number varchar(15),
    name varchar(100),
    photos varchar(1000),
    special_marks varchar(200),
    fk_animal_category int not null,
    fk_town int not null,
    fk_animal_status int not null DEFAULT 1,
    foreign key (fk_town) references town (id),
    foreign key (fk_animal_category) references animal_category (id),
    foreign key (fk_animal_status) references animal_status (id)
);


CREATE TABLE towns_service (
   id serial primary key,
   fk_town int not null,
   service varchar(100),
   price int not null,
   foreign key (fk_town) references town (id)
);

CREATE TABLE contract (
    id serial primary key,
    number varchar(7) not null ,
    start_date date not null,
    end_date date not null,
    fk_org_executor int not null,
    fk_org_client int not null,
    foreign key (fk_org_executor) references organization (id),
    foreign key (fk_org_client) references organization (id)
);

CREATE TABLE vaccination (
     id serial primary key,
     type text,
     date date,
     num_of_series text,
     date_of_expire date,
     position_of_doc text,
     fk_org int not null,
     fk_contract int not null,
     fk_animal int not null,
     foreign key (fk_org) references organization (id),
     foreign key (fk_animal) references animal (id),
     foreign key (fk_contract) references contract (id)
);

CREATE TABLE permission (
     id serial primary key,
     name text
);

CREATE TABLE permission_role (
    id serial primary key,
    fk_role int not null,
    fk_permission int not null,
    foreign key (fk_role) references role (id),
    foreign key (fk_permission) references permission (id)
);

CREATE TABLE status_statistic (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE statistics (
    id SERIAL PRIMARY KEY,
    date_start TIMESTAMP NOT NULL,
    date_finish TIMESTAMP NOT NULL,
    fk_status INT NOT NULL DEFAULT 1,
    update_status TIMESTAMP NOT NULL,
    FOREIGN KEY (fk_status) REFERENCES status_statistic(id)
);

CREATE TABLE statistic_town (
    id SERIAL PRIMARY KEY,
    count INT NOT NULL,
    cost FLOAT NOT NULL,
    fk_town INT NOT NULL,
    fk_statistic INT NOT NULL,
    FOREIGN KEY (fk_town) REFERENCES town(id),
    FOREIGN KEY (fk_statistic) REFERENCES statistics(id)
);

CREATE TABLE logging (
    id serial primary key,
    surname VARCHAR(255),
    name VARCHAR(255),
    patronymic VARCHAR(255),
    phone VARCHAR(20),
    email VARCHAR(255),
    organization VARCHAR(255),
    department_name VARCHAR(255),
    position VARCHAR(255),
    work_phone VARCHAR(20),
    work_email VARCHAR(255),
    login VARCHAR(255),
    date_time timestamp,
    object_instance_id varchar(255),
    object_description_after_action TEXT
);

CREATE OR REPLACE FUNCTION update_animal_status()
    RETURNS TRIGGER AS $$
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM vaccination
        WHERE fk_animal = NEW.fk_animal
    ) THEN
        UPDATE animal
        SET fk_animal_status = 1
        WHERE id = NEW.fk_animal;
    ELSE
        IF NOT EXISTS (
            SELECT 1
            FROM vaccination
            WHERE fk_animal = NEW.fk_animal
              AND date_of_expire >= CURRENT_DATE
        ) THEN
            UPDATE animal
            SET fk_animal_status = 1
            WHERE id = NEW.fk_animal;
        ELSE
            IF EXISTS (
                SELECT 1
                FROM vaccination
                WHERE fk_animal = NEW.fk_animal
                  AND date_of_expire >= CURRENT_DATE
                  AND date_of_expire <= CURRENT_DATE + INTERVAL '10 days'
            ) THEN
                UPDATE animal
                SET fk_animal_status = 3
                WHERE id = NEW.fk_animal;
            ELSE
                UPDATE animal
                SET fk_animal_status = 2
                WHERE id = NEW.fk_animal;
            END IF;
        END IF;
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION delete_animal_status()
    RETURNS TRIGGER AS $$
BEGIN
    UPDATE animal
    SET fk_animal_status = 1
    WHERE animal.id = OLD.fk_animal;

    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER update_vaccination_fk_animal_status
    AFTER INSERT OR UPDATE OF date_of_expire ON vaccination
    FOR EACH ROW
EXECUTE FUNCTION update_animal_status();

CREATE OR REPLACE TRIGGER delete_vaccination_fk_animal_status
    AFTER DELETE ON vaccination
    FOR EACH ROW
EXECUTE FUNCTION delete_animal_status();

INSERT INTO status_statistic 
    (name) 
VALUES
    ('Черновик'),
    ('Доработка'),
    ('Согласование у исполнителя Муниципального Контракта'),
    ('Согласовано у исполнителя Муниципального Контракта'),
    ('Утверждено у исполнителя Муниципального Контракта'),
    ('Согласовано в ОМСУ');

INSERT INTO animal_category
    (id, name)
VALUES
    (1, 'Кошка'),
    (2, 'Собака');

INSERT INTO animal_status (status)
VALUES 
    ('Не проводилась'),
    ('Вакцинировано'),
    ('Приближается срок вакцинирования');

INSERT INTO role
    (id, name)
VALUES
    (1, 'Куратор ВетСлужбы'),
    (2, 'Куратор по отлову'),
    (3, 'Куратор приюта'),
    (4, 'Оператор ВетСлужбы'),
    (5, 'Оператор по Отлову'),
    (6, 'Подписант ВетСлужбы'),
    (7, 'Подписант по отлову'),
    (8, 'Подписант приюта'),
    (9, 'Куратор ОМСУ'),
    (10, 'Оператор ОМСУ'),
    (11, 'Подписант ОМСУ'),
    (12, 'Оператор приюта'),
    (13, 'Ветврач приюта'),
    (14, 'super-admin');

INSERT INTO permission
    (id, name)
VALUES
    (1, 'create-animal'),
    (2, 'create-organization'),
    (3, 'create-contract'),
    (4, 'delete-animal'),
    (5, 'delete-organization'),
    (6, 'delete-contract'),
    (7, 'read-animal'),
    (8, 'read-organization'),
    (9, 'read-contract'),
    (10, 'update-animal'),
    (11, 'update-organization'),
    (12, 'update-contract'),
    (13, 'have-town'),
    (14, 'create-statistic');

INSERT INTO permission_role
    (fk_role, fk_permission)
VALUES
    (1,  7),
    (1,  8),
    (1,  9),
    (2,  7),
    (2,  8),
    (2,  9),
    (3,  7),
    (3,  8),
    (3,  9),
    (4,  7),
    (4,  8),
    (4,  9),
    (4,  2),
    (4,  5),
    (4,  11),
    (5,  7),
    (6,  7),
    (6,  8),
    (6,  9),
    (7,  7),
    (7,  8),
    (7,  9),
    (8,  7),
    (8,  8),
    (8,  9),
    (9,  7),
    (9,  8),
    (9,  9),
    (9,  13),
    (9,  14),
    (10,  7),
    (10,  2),
    (10,  5),
    (10,  8),
    (10,  11),
    (10,  3),
    (10,  6),
    (10,  9),
    (10,  12),
    (10,  13),
    (10,  14),
    (11,  7),
    (11,  8),
    (11,  9),
    (11,  13),
    (11,  14),
    (12,  1),
    (12,  4),
    (12,  7),
    (12,  10),
    (13,  1),
    (13,  4),
    (13,  7),
    (13,  10),
    (14,  1),
    (14,  2),
    (14,  3),
    (14,  4),
    (14,  5),
    (14,  6),
    (14,  7),
    (14,  8),
    (14,  9),
    (14,  10),
    (14,  11),
    (14,  12),
    (14,  14);

INSERT INTO town (name) VALUES ('Тюмень'), ('Новосибирск');

INSERT INTO organization
    (full_name, inn, kpp, address, type, legal_entity, fk_town)
VALUES
    ('ООО Аргон и сварка', '2355786', '4567', 'ул. Прокопия. д. 2', 'Приют', true, 1),
    ('ООО Клеточный кот', '442342', '42813', 'ул. Прокопия. д. 1', 'Приют', true, 2),
    ('ИП Конец бездомным', '443342', '43813', 'ул. Прокопия. д. 3', 'Заявитель', false, 1);

INSERT INTO users
    (login, password, fk_org, fk_role, surname, name, patronymic, phone, email, work_email, work_phone)
VALUES
    ('boss', 'p4ssw0rd', 1, 6, 'Smith', 'Smith', 'Smith', '+932309823', 'rvi@mi.ru', 'ew@e.re', '+330203-32'),
    ('master', 'aster', 1, 14, 'James', 'James', 'James', '+93293203',  'cece@cdc.e2', 'cdm@icm.ru', '+32903902'),
    ('towntest', '1', 1, 9, 'Сатана', 'Сатанин', 'укоушк', '+32903238', 'wewef@cei.45', 'fef@cdcd.434', '+02-3232390');

INSERT INTO animal
    (reg_num, fk_animal_category, sex, year_birth, electronic_chip_number, name, photos, special_marks, fk_town)
VALUES
    ('123123', 1, true, '2005-01-01', '7423423', 'Варя', 'на фотках кошка', 'черная, красивая, отсутствует хвост', 1),
    ('345234', 1, true, '2004-01-01', '74234423', 'Падик', 'на фотках кошка', 'серая, красивая, отсутствует нос', 1),
    ('123456', 2, false, '2000-01-01', '2342387', 'Аба', 'на фотках собака, красивая', 'рыжая, красивая, отсутствует нос и хвост', 2);


INSERT INTO towns_service (fk_town, service, price) VALUES
    (1, 'Вакцинация', 100),
    (2, 'Вакцинация', 72);

INSERT INTO contract
    (number, start_date, end_date, fk_org_executor, fk_org_client)
VALUES
    (1, '2003-01-01', '2005-01-01', 1, 3);

INSERT INTO vaccination
    (id, type, date, num_of_series, date_of_expire, position_of_doc, fk_org, fk_contract, fk_animal)
VALUES
    (1, 'бешенство', '2002-02-12', '434234234', '2015-03-12', 'Вет-врач-инъекционист', 2, 1, 1),
    (2, 'бешенство', '2023-02-12', '434234234', '2000-03-12', 'Вет-врач-инъекционист', 1, 1, 2),
    (3, 'бешенство', '2002-02-12', '434234234', '2022-03-12', 'Вет-врач-инъекционист', 2, 1, 1),
    (4, 'бешенство', '2010-02-12', '434234234', '2012-03-12', 'Вет-врач-инъекционист', 2, 1, 3),
    (5, 'бешенство', '2002-02-12', '434234234', '2014-03-12', 'Вет-врач-инъекционист', 1, 1, 1);