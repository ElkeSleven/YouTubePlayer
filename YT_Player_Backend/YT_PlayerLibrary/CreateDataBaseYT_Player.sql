create database dbYT_Player

use dbYT_Player

create table YoutubeSongs(
id int primary key IDENTITY(1,1),
title varchar(255) not null,
src varchar(255) not null unique,
startAtSec int null 
);

select * from YoutubeSongs
