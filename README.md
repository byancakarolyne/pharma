# PharmaApp

## Visão Geral

O projeto **PharmaApp** é uma aplicação web desenvolvida para gerenciar medicamentos, incluindo a adição de novos medicamentos e suas composições. A aplicação utiliza **Blazor** para a interface do usuário e **C#** para a lógica de backend.

## Funcionalidade do Frontend (Blazor)

A página **AdicionarMedicamentos.razor** é responsável por permitir que os usuários adicionem novos medicamentos ao sistema. A interface é construída utilizando componentes Blazor e inclui um formulário de edição (**EditForm**) para capturar os dados do medicamento.

### Campos do Formulário
- **Nome**: Campo de texto para o nome do medicamento.
- **Descrição**: Campo de texto para a descrição do medicamento.
- **Preço**: Campo numérico para o preço do medicamento.
- **Quantidade em Estoque**: Campo numérico para a quantidade em estoque do medicamento.
- **Composições**: Lista de composições do medicamento, cada uma contendo um ID de matéria-prima e a quantidade utilizada.

### Ações do Formulário
- **Adicionar Composição**: Botão para adicionar uma nova composição à lista.
- **Remover Composição**: Botão para remover uma composição específica da lista.
- **Adicionar Medicamento**: Botão para submeter o formulário e adicionar o medicamento ao sistema.

## Funcionalidade do Backend (C#)

A lógica de backend é implementada em C# e inclui a definição de DTOs (Data Transfer Objects) e a comunicação com a API.

### DTOs
- **MedicamentoDto**: Representa um medicamento e contém propriedades como Id, Nome, Descricao, QuantidadeEmEstoque, Preco e uma lista de Composicoes.
- **ComposicaoDto**: Representa uma composição de um medicamento e contém propriedades como MateriaPrimaId e QuantidadeUtilizada.

### Serviços
- **ApiService**: Serviço injetado na página Blazor para realizar operações de API, como adicionar um novo medicamento.

### Métodos
- **AdicionarComposicao**: Adiciona uma nova composição à lista de composições do medicamento.
- **RemoverComposicao**: Remove uma composição específica da lista de composições do medicamento.
- **AdicionarMedicamento**: Envia os dados do novo medicamento para a API e trata a resposta, exibindo mensagens de sucesso ou erro conforme necessário.

## Fluxo de Trabalho

1. O usuário preenche o formulário com os dados do novo medicamento.
2. O usuário pode adicionar ou remover composições conforme necessário.
3. Ao submeter o formulário, os dados são enviados para a API através do método **AdicionarMedicamento**.
4. A API processa os dados e retorna uma resposta indicando o sucesso ou falha da operação.
5. A interface do usuário exibe uma mensagem apropriada com base na resposta da API.

---

Esta documentação fornece uma visão geral das funcionalidades e do fluxo de trabalho da solução **PharmaApp**, tanto na parte do frontend desenvolvida com Blazor quanto na parte do backend desenvolvida em C#.
