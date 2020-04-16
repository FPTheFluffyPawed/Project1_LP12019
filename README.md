# 1º Projeto de Linguagens de Programação I 2019/2020

## Autoria
**Diogo Heriques (a21802132)**

- Fez a classe `Menu.cs`, tratando da lógica e programação da classe, fez o 
  movimento na classe `Wolf.cs` e a _win condition_ na classe `Game.cs` e 
  trabalhou na documentação do projeto, como o `README.md` e o fluxograma.

**Inácio Amerio (a21803493)**

- Início o projeto, organizou o trabalho como iria ser e ajudou os outros 
  membros do grupo com o trabalho. Trabalhou nas classes `Board.cs`, `Game.cs`, 
  `Sheep.cs`, `Wolf.cs` e `Position.cs`.

**João Dias (a21803573)**

- Fez a classe `Game.cs`, ajudou com o Diogo a classe `Menu.cs` e trabalhou na 
  lógica do movimento com o Inácio nas classes `Sheep.cs` e `Wolf.cs`.

[Repositório Git público.](https://github.com/FPTheFluffyPawed/Project1_LP12019)

## Arquitetura da solução

### Descrição da solução

O programa foi organizado de forma que as classes pudessem aceder umas as outras 
de forma ascendente. No caso das classes `Menu.cs`, `Board.cs` e `Game.cs`, foi 
feito a partir do `Program.cs` que comece no `Menu.cs`, e depois acedesse a 
`Game.cs` e depois acedesse a `Board.cs`.

As classes `Position.cs`, `Sheep.cs`, `Wolf.cs` são utilizadas para a 
organização de dados. A classe `Position.cs` é utilizado para guardar as 
posições de `Sheep.cs` e `Wolf.cs`, em que estas duas classes são utilizados no 
`Board.cs`.

`Wolf.cs` herda de `Sheep.cs`, pois estas classes partilham as mesmas funções, 
como por exemplo o método `Move(Board board)` que é utilizado para o movimento 
destas peças no `Board.cs`.

`Menu.cs` é o primeiro ecrã do nosso programa, e só trata em meter o utilizador 
no jogo através das opções fornecidas por esta classe.

### Fluxograma

![<Fluxograma>](images/Fluxograma.png)

### Referências

* O projeto
[Zombies and Humans](https://github.com/VideojogosLusofona/lp1_2018_p2_solucao), 
feito por o professor Nuno Fachada, foi utilizado como refêrencia para o
desenvolvimento deste projeto.
