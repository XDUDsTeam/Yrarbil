-- 这是 Yrarbil 后端数据库初始化文件
-- 用于 PostgreSQL 的


------------------------------------
-- API
------------------------------------
-- 0.0.0.0-tag
-- 0.0.0.0-B
-- 0.0.1.0-base
------------------------------------

\set ECHO_HIDDEN on
\echo '*\nYrarbil 数据库初始化\n*\n'

\echo '初始化 API 版本记录'








------------------------------------
-- FUNCTIONs DEFINEs
------------------------------------

------------------------------------
-- 删除已存在的表的
CREATE OR REPLACE FUNCTION
	drop_all_table(user_name IN VARCHAR,schema_name IN VARCHAR)
	RETURNS VOID
	AS $$
	DECLARE statements CURSOR FOR
		SELECT tablename FROM pg_tables
			WHERE tableowner = user_name AND
						schemaname = schema_name;
	BEGIN
		FOR stmt IN statements LOOP
			EXECUTE 'DROP TABLE ' || quote_ident(stmt.tablename) || ' CASCADE;';
		END LOOP;
	END;
$$ LANGUAGE plpgsql;

------------------------------------
-- 大小流水号的比较
CREATE OR REPLACE FUNCTION
	func_sernum_eq(b TEXT,s INT,d DATE)
	RETURNS BOOLEAN
	AS $$
	BEGIN
		RETURN (b=s||'@'||d);
	END;
$$ LANGUAGE plpgsql;



------------------------------------

SELECT drop_all_table('qinka','public');

------------------------------------
-- TABLES
------------------------------------

------------------------------------
-- 创建 版本号记录表
CREATE TABLE table_version
(
	main	INT  NOT NULL,
	snd		INT  ,
	trd		INT  ,
	fix		INT	 ,
	tag		CHAR(40)
);

-- 添加数据
INSERT INTO table_version
VALUES(
	-- 见 API
	0,0,0,0,
	'tag'
);
INSERT INTO table_version
VALUES(
	-- 见 API
	0,0,0,0,
	'B'
);
INSERT INTO table_version
VALUES(
	-- 见 API
	0,0,1,0,
	'base'
);


-------------------------------------
--  图书管理数据
-------------------------------------
-- 创建 图书记录表
CREATE TABLE table_bookinfo
(
	isbn			BIGINT NOT NULL PRIMARY KEY,
	bookname		CHAR(128),
	author			CHAR(64),
	publish_local	TEXT,
	publish_house   CHAR(64),
	publish_date	DATE,
	library_local	TEXT,
	library_index	CHAR(40),
	bought_price	INT,
	bought_date 	DATE
);

--------------------------------------
-- 创建 图书实体记录
CREATE TABLE table_bookitem
(
	barcode			BIGINT NOT NULL PRIMARY KEY,
	isbn			BIGINT NOT NULL,
	on_shelf		BOOLEAN NOT NULL,
	is_there		BOOLEAN NOT NULL,
	latest_opt_id	CHAR(64)
);
--------------------------------------
-- 创建 图书操作记录 入库（购买）
CREATE TABLE table_bookopt_in
(
	big_serial_number			TEXT NOT NULL PRIMARY KEY,
	bought_price				INT NOT NULL,
	isbn						BIGINT NOT NULL,
	barcode						BIGINT NOT NULL,
	note						TEXT
);

--------------------------------------
-- 创建 图书操作记录 出库（销毁）
CREATE TABLE table_bookopt_out
(
	big_serial_number	TEXT NOT NULL PRIMARY KEY,
	reason				TEXT NOT NULL,
	note				TEXT
);


--------------------------------------
-- 创建 图书操作记录
CREATE TABLE table_bookopt_main
(
	big_serial_number			TEXT NOT NULL PRIMARY KEY,
	reader_barcode				BIGINT NOT NULL,
	book_barcode				BIGINT NOT NULL,
	time_lmt					INT[] NOT NULL,
	return_date					DATE
);

--------------------------------------
-- 创建 图书预约记录
CREATE TABLE table_bookopt_appointment
(
	big_serial_number			TEXT NOT NULL PRIMARY KEY,
	reader_barcode				BIGINT NOT NULL,
	book_barcode				BIGINT NOT NULL,
	appointment_date			DATE NOT NULL
);

--------------------------------------
-- 创建 处罚记录
CREATE TABLE table_punish
(
	big_serial_number			TEXT NOT NULL PRIMARY KEY,
	reader_barcode				BIGINT NOT NULL,
	cash						MONEY NOT NULL,
	reason						TEXT NOT NULL
);

--------------------------------------
-- 创建 读者数据
CREATE TABLE table_reader
(
	barcode					TEXT NOT NULL PRIMARY KEY, --已修改
	reader_name				TEXT NOT NULL,
	idcard_type				CHAR(40),
	idcard_id				TEXT,
	debt					MONEY,
	enter_password		TEXT NOT NULL DEFAULT '111111'
);




--------------------------------------
-- 创建 操作数据记录
CREATE TABLE table_opt
(
	small_serial_number			INT NOT NULL,
	opt_date					DATE NOT NULL,
	opt_usr_type				SMALLINT NOT NULL,
	opt_usr_id					BIGINT	NOT NULL
);


--------------------------------------
-- 创建 系统管理员数据
CREATE TABLE table_adminer
(
	admin_id			INT NOT NULL PRIMARY KEY,
	admin_passwd	TEXT NOT NULL DEFAULT '222222'
);


--------------------------------------
-- 临时 ID 秘钥 表
CREATE TABLE table_tmpidkey
(
	tmpid TEXT NOT NULL PRIMARY KEY,
	timeend TIMESTAMP WITH TIME ZONE NOT NULL,
	id TEXT NOT NULL
);

\echo '*\nYrarbil 数据库初始化完毕\n*\n'


\set ECHO_HIDDEN off
