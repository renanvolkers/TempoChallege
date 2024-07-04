FROM mcr.microsoft.com/mssql-tools

# install dos2unix
RUN apt-get update && apt-get install -y dos2unix

COPY 01BaseTempoCriarBanco.sql /tmp/01BaseTempoCriarBanco.sql
COPY 02BaseTempoDados.sql /tmp/02BaseTempoDados.sql
COPY init-baseTempo.sh /tmp/init-baseTempo.sh

## Convert terminador of line in the file of script
RUN dos2unix /tmp/init-baseTempo.sh

RUN chmod +x /tmp/init-baseTempo.sh

ENTRYPOINT ["/bin/bash", "/tmp/init-baseTempo.sh"]