# Banco de Dados - PharmaDB

## 1. Geral
Este banco de dados foi projetado para gerenciar a produção, venda e estoque de medicamentos, bem como o relacionamento com clientes e pedidos. Ele contém tabelas para armazenar informações sobre matérias-primas, medicamentos, composição de medicamentos, clientes, pedidos e itens de pedidos.

## 2. Estrutura das Tabelas

### 2.1 MateriasPrimas
Armazena informações sobre as matérias-primas utilizadas na fabricação dos medicamentos.

| Campo              | Tipo        | Restrições                          | Descrição                                      |
|--------------------|------------|--------------------------------|------------------------------------------------|
| Id                | INT        | PRIMARY KEY, IDENTITY(1,1)   | Identificador único da matéria-prima.          |
| Nome              | NVARCHAR(255) | NOT NULL                        | Nome da matéria-prima.                        |
| Descricao         | NVARCHAR(500) | NULL                            | Descrição da matéria-prima.                    |
| QuantidadeEmEstoque | INT       | NOT NULL                        | Quantidade da matéria-prima em estoque.       |
| DataValidade      | DATE        | NOT NULL                        | Data de validade da matéria-prima.            |

---

### 2.2 Medicamentos
Armazena informações sobre os medicamentos disponíveis para venda.

| Campo             | Tipo        | Restrições                          | Descrição                                    |
|-------------------|------------|--------------------------------|----------------------------------------|
| Id               | INT        | PRIMARY KEY, IDENTITY(1,1)   | Identificador único do medicamento.   |
| Nome             | NVARCHAR(255) | NOT NULL                        | Nome do medicamento.                  |
| Descricao        | NVARCHAR(500) | NULL                            | Descrição do medicamento.              |
| Preco            | DECIMAL(18,2) | NOT NULL                        | Preço do medicamento.                  |
| QuantidadeEmEstoque | INT      | NOT NULL                        | Quantidade disponível em estoque.     |

---

### 2.3 ComposicaoMedicamentos
Tabela intermediária que define a composição dos medicamentos a partir das matérias-primas.

| Campo             | Tipo  | Restrições                          | Descrição                                       |
|-------------------|------|--------------------------------|-------------------------------------------|
| Id               | INT  | PRIMARY KEY, IDENTITY(1,1)   | Identificador único da composição.       |
| MedicamentoId    | INT  | FOREIGN KEY REFERENCES Medicamentos(Id) ON DELETE CASCADE | Referência ao medicamento. |
| MateriaPrimaId   | INT  | FOREIGN KEY REFERENCES MateriasPrimas(Id) ON DELETE CASCADE | Referência à matéria-prima. |
| QuantidadeUtilizada | INT | NOT NULL                        | Quantidade da matéria-prima utilizada. |

---

### 2.4 Clientes
Armazena informações sobre os clientes.

| Campo     | Tipo        | Restrições                          | Descrição                                |
|-----------|------------|--------------------------------|--------------------------------|
| Id        | INT        | PRIMARY KEY, IDENTITY(1,1)   | Identificador único do cliente.|
| Nome      | NVARCHAR(255) | NOT NULL                        | Nome do cliente.                 |
| CPF       | CHAR(11)   | UNIQUE, NOT NULL               | CPF do cliente.                  |
| Endereco  | NVARCHAR(500) | NOT NULL                        | Endereço do cliente.             |
| Telefone  | NVARCHAR(20)  | NOT NULL                        | Telefone do cliente.             |
| Email     | NVARCHAR(255) | UNIQUE, NOT NULL               | Email do cliente.                |

---

### 2.5 Pedidos
Armazena informações sobre os pedidos realizados pelos clientes.

| Campo     | Tipo       | Restrições                          | Descrição                               |
|-----------|-----------|--------------------------------|--------------------------------|
| Id        | INT       | PRIMARY KEY, IDENTITY(1,1)   | Identificador único do pedido. |
| ClienteId | INT       | FOREIGN KEY REFERENCES Clientes(Id) ON DELETE CASCADE | Referência ao cliente que fez o pedido. |
| DataPedido | DATETIME  | DEFAULT GETDATE()            | Data em que o pedido foi realizado. |
| ValorTotal | DECIMAL(18,2) | NOT NULL                        | Valor total do pedido.          |

---

### 2.6 ItensPedido
Tabela intermediária que representa os itens de um pedido.

| Campo         | Tipo       | Restrições                          | Descrição                              |
|--------------|-----------|--------------------------------|--------------------------------|
| Id          | INT       | PRIMARY KEY, IDENTITY(1,1)   | Identificador único do item.  |
| PedidoId    | INT       | FOREIGN KEY REFERENCES Pedidos(Id) ON DELETE CASCADE | Referência ao pedido. |
| MedicamentoId | INT       | FOREIGN KEY REFERENCES Medicamentos(Id) ON DELETE CASCADE | Referência ao medicamento. |
| Quantidade  | INT       | NOT NULL                        | Quantidade do medicamento no pedido. |
| PrecoUnitario | DECIMAL(18,2) | NOT NULL                        | Preço unitário do medicamento. |

## 3. Relacionamentos

- **Medicamentos** e **MateriasPrimas** possuem uma relação *M:N* por meio da tabela **ComposicaoMedicamentos**.
- **Clientes** podem fazer vários **Pedidos**, estabelecendo uma relação *1:N*.
- **Pedidos** podem conter vários **Medicamentos**, estabelecendo uma relação *M:N* por meio da tabela **ItensPedido**.

## 4. Regras de Negócio

1. Cada **Medicamento** pode ser composto por várias **MateriasPrimas** e vice-versa.
2. Um **Pedido** pertence a um único **Cliente**, mas um **Cliente** pode fazer vários **Pedidos**.
3. Um **Pedido** pode conter vários **Medicamentos** e cada **Medicamento** pode estar em vários **Pedidos**.
4. O valor total do **Pedido** é calculado somando o preço unitário dos medicamentos multiplicado por suas quantidades.

