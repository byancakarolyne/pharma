use PharmaDB;

/*
    SELECT * FROM MateriasPrimas;
    SELECT * FROM Medicamentos;
    SELECT * FROM ComposicaoMedicamentos;
    SELECT * FROM Clientes;
    SELECT * FROM Pedidos;
    SELECT * FROM ItensPedido;
*/


-- Inserindo matérias-primas
INSERT INTO MateriasPrimas (Nome, Descricao, QuantidadeEmEstoque, DataValidade) VALUES
('Ácido Acetilsalicílico', 'Usado na fabricação de analgésicos', 500, '2025-12-31'),
('Paracetamol', 'Componente ativo para medicamentos antitérmicos', 300, '2026-06-30');

-- Inserindo medicamentos
INSERT INTO Medicamentos (Nome, Descricao, Preco, QuantidadeEmEstoque) VALUES
('Aspirina', 'Analgésico e anti-inflamatório', 10.50, 200),
('Tylenol', 'Reduz febre e alivia dores', 15.75, 150);

-- Inserindo composição dos medicamentos
INSERT INTO ComposicaoMedicamentos (MedicamentoId, MateriaPrimaId, QuantidadeUtilizada) VALUES
(1, 1, 50),  -- Aspirina usa Ácido Acetilsalicílico
(2, 2, 30);  -- Tylenol usa Paracetamol

-- Inserindo clientes
INSERT INTO Clientes (Nome, CPF, Endereco, Telefone, Email) VALUES
('Carlos Silva', '12345678901', 'Avenida Paulista, 1000', '11987654321', 'carlos@email.com'),
('Maria Oliveira', '98765432100', 'Rua das Flores, 500', '11976543210', 'maria@email.com');

-- Inserindo pedidos
INSERT INTO Pedidos (ClienteId, DataPedido, ValorTotal) VALUES
(1, GETDATE(), 31.50),
(2, GETDATE(), 21.00);

-- Inserindo itens nos pedidos
INSERT INTO ItensPedido (PedidoId, MedicamentoId, Quantidade, PrecoUnitario) VALUES
(1, 1, 2, 10.50),  -- Pedido do Carlos: 2 Aspirinas
(1, 2, 1, 15.75),  -- Pedido do Carlos: 1 Tylenol
(2, 2, 2, 15.75);  -- Pedido da Maria: 2 Tylenols
