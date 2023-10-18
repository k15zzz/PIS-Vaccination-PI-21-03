DROP TABLE IF EXISTS organizations_contracts;
DROP TABLE IF EXISTS vaccination;
DROP TABLE IF EXISTS contract;
DROP TABLE IF EXISTS animal;
DROP TABLE IF EXISTS towns_service;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS organization;
DROP TABLE IF EXISTS town;
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
   fk_service int not null,
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
    number_of_org int not null,
    fk_contract int not null,
    fk_organization int not null,
    primary key (number_of_org, fk_contract),
    foreign key (fk_contract) references contract (id),
    foreign key (fk_organization) references organization (id)
)