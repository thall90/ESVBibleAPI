create schema "EsvBible"

create table "EsvBible.Book"
(
    "Id"   serial      not null
        constraint book_pk
            primary key,
    "Name" varchar(50) not null
);

alter table "EsvBible.Book"
    owner to postgres;

create unique index book_id_uindex
    on "Book" ("Id");

create table "EsvBible.Chapter"
(
    "Id"        serial  not null
        constraint chapter_pk
            primary key,
    "Number"    integer not null,
    "EsvBookId" integer not null
        constraint chapter_book_id_fk
            references "Book"
);

alter table "EsvBible.Chapter"
    owner to postgres;

create unique index chapter_id_uindex
    on "Chapter" ("Id");

create table "EsvBible.Verse"
(
    "Id"           serial  not null
        constraint verse_pk
            primary key,
    "EsvChapterId" integer not null
        constraint verse_chapter_id_fk
            references "Chapter",
    "Number"       integer not null,
    "Value"        text    not null
);

alter table "EsvBible.Verse"
    owner to postgres;

create unique index verse_id_uindex
    on "Verse" ("Id");


