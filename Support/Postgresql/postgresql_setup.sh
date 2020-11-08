DATABASEPASSWORD=TestDbPass9456!

docker pull postgres

docker run -e POSTGRES_PASSWORD=$DATABASEPASSWORD -p 5432:5432 --name some-postgres -d postgres

docker start some-postgres
