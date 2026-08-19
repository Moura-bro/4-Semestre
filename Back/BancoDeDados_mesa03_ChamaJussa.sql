CREATE DATABASE dbTecnico_Chamados

USE dbTecnico_Chamados

CREATE TABLE Usuario(
 idUsuario      UNIQUEIDENTIFIER PRIMARY KEY DEFAULT ((NEWID())),
 Nome           NVARCHAR(255)            NOT NULL,
 Email          NVARCHAR(255)    UNIQUE  NOT NULL,
 Senha          NVARCHAR(255)            NOT NULL,
 FotoPerfil     NVARCHAR(255)
);
GO

CREATE TABLE Chamado(
 idChamado        UNIQUEIDENTIFIER PRIMARY KEY       DEFAULT ((NEWID())),
 Titulo           NVARCHAR(255)            NOT NULL,
 Equipamento      NVARCHAR(255)            NOT NULL,
 Setor            NVARCHAR(255)            NOT NULL,
 Descricao        NVARCHAR(255)            NOT NULL,
 FotoDoProblema   NVARCHAR(255)                    ,
 Status_OS        NVARCHAR(255)            NOT NULL,
 Data_Criacao     DATETIME                 NOT NULL  DEFAULT  GETDATE(),
 Data_Atualizacao DATETIME                 NOT NULL,
 IdUsuario        UNIQUEIDENTIFIER         NOT NULL 
   FOREIGN KEY(idUsuario) REFERENCES Usuario(idUsuario)
);
GO


CREATE TABLE Notificacao (
  idNotificacao   UNIQUEIDENTIFIER  PRIMARY KEY      DEFAULT  ((NEWID())),
  Titulo          NVARCHAR(255)             NOT NULL,
  Mensagem        NVARCHAR(255)             NOT NULL,
  Verificada      BIT                                DEFAULT 0,
  DataNotificacao DATETIME                  NOT NULL DEFAULT   GETDATE(),
  IdChamado       UNIQUEIDENTIFIER          NOT NULL,
  IdUsuario       UNIQUEIDENTIFIER          NOT NULL,
     FOREIGN KEY (idChamado) REFERENCES Chamado(idChamado),
     FOREIGN KEY(idUsuario) REFERENCES Usuario(idUsuario)
)
GO

SELECT * FROM Usuario;

SELECT * FROM Chamado; 

SELECT * FROM Notificacao;