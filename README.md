# FitTrack System (Simulação de Projeto Real)
> Projeto fictício criado para simular o atendimento a demandas reais de um cliente no setor de treinamento fitness, utilizando ASP.NET Core e SQLite.

## 🧾 Contexto do Cliente
O estúdio FitTrack busca uma solução simples e eficiente para gerenciar seus clientes e registrar sessões de treinamento.

## 🧠 Tecnologias
- ASP.NET Core 8 (Minimal APIs)
- SQLite
- Swagger
- Entity Framework Core

## 🧩 Demanda Inicial
O cliente solicitou:

> “A gente tem um pequeno estúdio de personal trainers e hoje tudo é feito em planilha e grupo de WhatsApp.
> Queria um sistema pra organizar os treinos dos alunos.
> Tipo, cada aluno tem o treino dele, com os exercícios e anotações, e a gente precisa conseguir acompanhar a evolução — tipo peso, medidas e desempenho.
> Também seria bom poder ver um histórico, pra comparar o progresso de cada um.
> No futuro talvez a gente queira transformar isso num aplicativo pros alunos verem o treino deles direto, mas por enquanto pode ser só algo interno pra gente usar.”

## ✅ Entregas da Sprint 1
- CRUD de clientes e sessões de treino
- Persistência em SQLite
- Endpoints documentados com Swagger

## 📣 Relato do Cliente - Devolutiva 1

> "Então, agora que a base do sistema já está funcionando, queria começar a usar isso de verdade no dia a dia. Mas percebi que vamos precisar dar alguns passos a mais. Primeiro, seria importante ter um jeito de entrar no sistema com usuário e senha, só pra garantir que só o pessoal daqui mexa nas coisas dos alunos.
> Também sentimos falta de um lugar onde eu consiga ver a agenda da semana. Queria poder marcar as sessões dos alunos, cancelar quando alguém avisa que não vem e organizar tudo num só lugar. Isso facilitaria muito.
> Outra coisa é que seria ótimo receber avisos dentro do sistema quando um aluno tem avaliação chegando ou quando o plano dele está perto de vencer. Não precisa mandar mensagem pra ninguém ainda, só mostrar ali pra gente mesmo.
> E por último, queria ter uma visão rápida de quem está evoluindo bem, quem está faltando muito ou quem parece estar travado. Um painelzinho simples já ajudaria bastante. Ah, e como hoje estamos usando tudo só pela API, vamos acabar precisando de uma tela mesmo pra usar isso tudo."

---

## 🗂️ Planejamento das Próximas Sprints

### 🧱 Sprint 2 — Acesso ao Sistema
- Criar mecanismo de login (usuário/senha).
- Restringir acesso: somente equipe do estúdio.
- Criar a primeira interface para permitir entrar no sistema.

### 🗓️ Sprint 3 — Agenda Semanal
- Exibir agenda da semana.
- Marcar sessões para alunos.
- Cancelar sessões quando necessário.
- Organizar visualmente horários e status.

### 🔔 Sprint 4 — Alertas Internos
- Exibir avisos de avaliações próximas.
- Exibir avisos de planos prestes a vencer.
- Criar área onde esses avisos ficam visíveis dentro do sistema.

### 📊 Sprint 5 — Painel de Evolução
- Mostrar visão geral de evolução dos alunos.
- Destacar quem está indo bem, quem está faltando e quem está travado.
- Criar primeira tela de acompanhamento simples.
