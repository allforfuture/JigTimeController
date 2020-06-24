CREATE TABLE operate_history(
	id				INTEGER		PRIMARY KEY		AUTOINCREMENT,
	jig_id			TEXT		NOT NULL,
	location		TEXT		NOT NULL,
	oven_time		INTEGER		NOT NULL,
	creat_time		DATETIME	NOT NULL,
	operate_type	TEXT		NOT NULL
);

jig表
history_id		jig_id		Location	OvenTime	StartTime	EndTime			TimeOut