CREATE DATABASE `proyecto` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
CREATE TABLE bankaccount (
    serial        INTEGER NOT NULL,
    money         FLOAT NOT NULL
);



ALTER TABLE bankaccount ADD CONSTRAINT bankaccount_pk PRIMARY KEY ( serial );

CREATE TABLE `User` (
    `e-mail`           VARCHAR(20) NOT NULL,
    password           VARCHAR(12) NOT NULL,
    bankaccount_serial INTEGER NOT NULL
);

CREATE UNIQUE INDEX user__idx ON
    `User` (
        bankaccount_serial
    ASC );

ALTER TABLE `User` ADD CONSTRAINT user_pk PRIMARY KEY ( `e-mail` );


ALTER TABLE `User`
    ADD CONSTRAINT user_bankaccount_fk FOREIGN KEY ( bankaccount_serial )
        REFERENCES bankaccount ( serial );