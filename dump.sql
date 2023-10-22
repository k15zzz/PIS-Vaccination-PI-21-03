DROP TABLE IF EXISTS organizations_contracts;
DROP TABLE IF EXISTS vaccination;
DROP TABLE IF EXISTS contract;
DROP TABLE IF EXISTS animal;
DROP TABLE IF EXISTS towns_service;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS organization;
DROP TABLE IF EXISTS town;
DROP TABLE IF EXISTS permission_role;
DROP TABLE IF EXISTS permission;
DROP TABLE IF EXISTS role;

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
    full_name varchar(20),
    inn char(10),
    kpp char(8),
    address varchar(100),
    type varchar(100),
    legal_entity bit(1),
    fk_town int not null,
    foreign key (fk_town) references town (id)
);

CREATE TABLE users (
    id serial primary key,
    login varchar(100),
    password varchar(100),
    fk_org int not null,
    fk_role int not null,
    foreign key (fk_role) references role (id),
    foreign key (fk_org) references organization (id)
);

CREATE TABLE animal (
    id serial primary key,
    reg_num int8,
    category bit(1),
    sex bit(1),
    year_birth time,
    electronic_chip_number varchar(15),
    name varchar(100),
    photos varchar(1000),
    special_marks varchar(200),
    fk_town int not null,
    foreign key (fk_town) references town (id)
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
    number varchar(7),
    start_date time,
    end_date time
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
     foreign key (fk_org) references organization (id),
     foreign key (fk_contract) references contract (id)
);

CREATE TABLE organizations_contracts (
    id serial primary key,
    number_of_org int not null,
    fk_contract int not null,
    fk_organization int not null,
--     primary key (number_of_org, fk_contract),
    foreign key (fk_contract) references contract (id),
    foreign key (fk_organization) references organization (id)
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
    ('ООО Аргон и сварка', '2355786', '4567', 'ул. Прокопия. д. 2', 'Приют', b'1', 1), 
    ('ООО Клеточный кот', '442342', '42813', 'ул. Прокопия. д. 1', 'Приют', b'1', 2);

INSERT INTO users 
    (login, password, fk_org, fk_role) 
VALUES 
    ('boss', 'p4ssw0rd', 1, 6), 
    ('master', 'aster', 1, 14), 
    ('towntest', '1', 1, 9);

INSERT INTO animal 
    (reg_num, category, sex, year_birth, electronic_chip_number, name, photos, special_marks, fk_town) 
VALUES 
    ('123123', b'1', b'1', '2005-01-01 00:00:00', '7423423', 'Варя', 'на фотках кошка', 'черная, красивая, отсутствует хвост', 1), 
    ('345234', b'1', b'0', '2004-01-01 00:00:00', '74234423', 'Падик', 'на фотках кошка', 'серая, красивая, отсутствует нос', 1), 
    ('123456', b'0', b'1', '2000-01-01 00:00:00', '2342387', 'Аба', 'на фотках собака, красивая', 'рыжая, красивая, отсутствует нос и хвост', 2);


INSERT INTO towns_service (fk_town, service, price) VALUES
    (1, 'Вакцинация', 100),
    (2, 'Вакцинация', 72);

INSERT INTO contract 
    (number, start_date, end_date)
VALUES
    (1, '2003-01-01 00:00:00', '2005-01-01 00:00:00');

INSERT INTO vaccination 
    (id, type, date, num_of_series, date_of_expire, position_of_doc, fk_org, fk_contract)
VALUES
    (1, 'бешенство', '2002-02-12', '434234234', '2015-03-12', 'Вет-врач-инъекционист', 2, 1),
    (2, 'бешенство', '2023-02-12', '434234234', '2000-03-12', 'Вет-врач-инъекционист', 1, 1),
    (3, 'бешенство', '2002-02-12', '434234234', '2022-03-12', 'Вет-врач-инъекционист', 2, 1),
    (4, 'бешенство', '2010-02-12', '434234234', '2012-03-12', 'Вет-врач-инъекционист', 2, 1),
    (5, 'бешенство', '2002-02-12', '434234234', '2014-03-12', 'Вет-врач-инъекционист', 1, 1);

INSERT INTO contract
    (number, start_date, end_date)
VALUES
    (1, '2003-01-01 00:00:00', '2004-01-01 00:00:00');

INSERT INTO organizations_contracts
    (number_of_org, fk_contract, fk_organization)
VALUES 
    (1, 1, 1);
