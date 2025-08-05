
# 📚 Projeto API Livraria

Esta é uma API REST desenvolvida em **ASP.NET Core (.NET 8)** para gerenciar uma livraria, permitindo operações de CRUD em livros e o registro de vendas com base em regras de negócio específicas como estoque, gênero e tipo do livro.

---

## 🚀 Funcionalidades

- ✅ Cadastro, listagem, edição e remoção de livros (CRUD)
- ✅ Registro de vendas com lógica de negócio
  - Verificação de estoque disponível
  - Cálculo de valor total baseado no preço de venda
  - Atualização de estoque
  - Venda baseada no gênero/tipo do livro
- ✅ Resposta com DTOs personalizados
- ✅ Uso de AutoMapper para conversão de entidades e DTOs
- 🚧 Integração com Twilio (em implementação)

---

## 🗂️ Estrutura de Pastas

```
Biblioteca/
│
├── Controllers/           # Endpoints da API
├── Data/                  # DbContext e configuração do banco
├── Dtos/                  # Objetos de transferência de dados
├── Interfaces/            # Interfaces de serviços
├── Mappings/              # Configuração do AutoMapper
├── Models/                # Entidades do sistema (Produto, Vendas)
├── Services/              # Lógica de negócio (VendaService, ProdutoService)
├── appsettings.json       # Configurações da aplicação
└── Program.cs             # Entry point e DI
```

---

## 🧠 Principais Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- AutoMapper
- Swagger (Swashbuckle)
- SQL Server LocalDB
- Twilio (em progresso)

---

## 🧾 Exemplo de Venda (Regra de Negócio)

- A venda só ocorre se:
  - O produto existe no banco
  - Há estoque suficiente
- O sistema calcula o valor total: `quantidade * valorVenda`
- O estoque é decrementado
- A venda é registrada com data e valor total

**Resposta esperada:**

```json
{
  "mensagem": "Venda Realizada com Sucesso !",
  "nomeProduto": "Livro X",
  "quantidadeVendida": 2,
  "valorTotal": 80.0
}
```

---

## 🔧 Em Desenvolvimento

- Integração com Twilio para envio de notificações via WhatsApp/SMS após a venda
- Autenticação com JWT
- Testes unitários com xUnit e Moq

---

## 🧑‍💻 Desenvolvedor

- **Caio de Souza Nery**
- Projeto pessoal para aprendizado prático com ASP.NET Core

---


## ✅ To-do List

- [x] CRUD de livros
- [x] Lógica de venda com regras
- [x] AutoMapper configurado
- [ ] Notificações com Twilio
- [ ] Autenticação JWT
- [ ] Testes automatizados
