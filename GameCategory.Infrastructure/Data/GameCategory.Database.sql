CREATE TABLE category
(
	category_id serial primary key,
	name_category varchar(50) not null,
	descripcion_category varchar(100) not null,
	active bit not null default 0::bit
);

create table game
(
	game_id serial primary key,
	name_game varchar(50) not null,
	descripcption varchar(200) not null,
	active bit not null default 0::bit
);

create table game_category
(
	game_category_id serial primary key,
	category_id int not null references category(category_id),
	game_id int not null references game(game_id),
	active bit not null default 0::bit
);