echo "Wating o SQL Server start..."
counter=0
until /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P SqlServer2019! -Q "SELECT 1" &>/dev/null; do
  ((counter++))
  echo "Tryng $counter: Waiting conection with SQL Server..."
  sleep 5
done
echo "Conectado ao SQL Server!"
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P SqlServer2019! -d master -i /tmp/01BaseTempoCriarBanco.sql &&
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P SqlServer2019! -d TempoChallengeKnights -i /tmp/02BaseTempoDados.sql