SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

SET search_path = public, pg_catalog;


SET default_tablespace = '';


SET default_with_oids = false;

\connect local_test

CREATE SEQUENCE SEQ_users;

CREATE TABLE users (
    id bigint DEFAULT nextval(('SEQ_users'::text)::regclass) NOT NULL,
    username character varying(40),
    password character varying(100),
    mail character varying(200),
    full_name character varying(150),
    created timestamp without time zone DEFAULT now() NOT NULL,
    modified timestamp without time zone DEFAULT now() NOT NULL
);

ALTER TABLE public.users OWNER TO sysdba;