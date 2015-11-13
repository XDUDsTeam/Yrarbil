##################################
##  Yrarbil 数据库备份
##################################

##################################
## 需要设置一下环境变量
## $YRARBIL_DB_HOST
## $YRARBIL_DB_PORT
## $YRARBIL_DB_USR
## $YRARBIL_DB_PASSWD
## $YRARBIL_DB_NAME
###################################


echo 'Yrarbil 数据备份'

pg_dump --host=$YRARBIL_DB_HOST --port=$YRARBIL_DB_PORT --username=$YRARBIL_DB_USR -c $YRARBIL_DB_NAME > $PGDATA/backup/$(date)

echo '之后可以使用 pg_restore 来恢复'