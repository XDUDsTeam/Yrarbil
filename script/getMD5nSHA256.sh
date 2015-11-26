#/bin/bash

if [ $1 ]
  then
    echo "$1 的MD5 值是"
    echo $1 | md5sum
    echo "$1 的 SHA256 值是"
    echo $1 | sha256sum
  else
  echo "你应该输入些啥"
fi
