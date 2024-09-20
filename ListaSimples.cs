using System;
using System.Windows.Forms;

public class ListaSimples<Dado>
             where Dado : IComparable<Dado>
{
    NoLista<Dado> primeiro, ultimo, anterior, atual;
    int quantosNos;
    bool primeiroAcessoDoPercurso;

    public ListaSimples()
    {
        primeiro = ultimo = anterior = atual = null;
        quantosNos = 0;
        primeiroAcessoDoPercurso = false;
    }

    public void IniciarPercursoSequencial()
    {
        primeiroAcessoDoPercurso = true;
        atual = primeiro;
        anterior = null;
    }

    public bool PodePercorrer()
    {
        if (!primeiroAcessoDoPercurso)
        {
            anterior = atual;
            atual = atual.Prox;
        }

        else
            primeiroAcessoDoPercurso = false;

        return atual != null;
    }

    public void PercorrerLista()
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }
    public bool EstaVazia
    {
        get => primeiro == null;
    }
    public NoLista<Dado> Primeiro
    {
        get => primeiro;
    }

    public NoLista<Dado> Atual { get => atual; set => atual = value; }

    public NoLista<Dado> Ultimo
    {
        get => ultimo;
    }
    public int QuantosNos
    {
        get => quantosNos;
    }

    public bool ExisteDado(Dado procurado)
    {
        // atual apontará o nó com o Dado procurado, e
        // anterior apontará o nó anterior a este
        anterior = atual = null;
        if (EstaVazia)
            return false;

        // se a lista não está vazia, podemos usar os ponteiros da lista

        // se o campo chave do Dado procurado é menor que o
        // campo chave do primeiro nó, o Dado procurado não existe

        if (procurado.CompareTo(primeiro.Info) < 0)
        {
            atual = primeiro;  // anterior continua com null
            return false;
        }

        // se o campo chave do Dado procurado é maior que o
        // campo chave do último nó, o Dado procurado não existe

        if (procurado.CompareTo(ultimo.Info) > 0)
        {
            anterior = ultimo;  // atual continua com null
            return false;
        }

        // o Dado procurado pode estar na lista, temos que procurar
        // um a um, até encontrá-lo ou achar uma chave maior que a 
        // do procurado

        atual = primeiro;
        bool achou = false;      // fica true quando acha chave igual
        bool maiorOuFim = false; // fica true quando acha chave maior
                                 // ou chegou no fim da lista
        while (!achou && !maiorOuFim)
            if (atual == null)
                maiorOuFim = true;
            else // como atual != null, podemos acessar o nó atual
                 // se atual aponta nó com chave maior que a procurada
                if (atual.Info.CompareTo(procurado) > 0)
                maiorOuFim = true;
            else
                  // testamos se as chaves são iguais
                  if (atual.Info.CompareTo(procurado) == 0)
                achou = true; // encontramos o nó com a chave procurada,
                              // e atual aponta para ele
            else
            {
                anterior = atual;
                atual = atual.Prox;
            }

        return achou;  // anterior e atual definem região do nó
    }

    public bool Remover(Dado dadoARemover)
    {
        if (ExisteDado(dadoARemover))
        {  // lista não está vazia, temos um 1o e um último
            if (atual == primeiro)  // caso especial
            {
                primeiro = primeiro.Prox;
                atual = primeiro;
                if (primeiro == null)  // se esvaziou a lista!!!!
                    ultimo = null;     // ultimo passa a apontar nada
            }
            else
                if (atual == ultimo)  // caso especial
            {
                ultimo = anterior;
                ultimo.Prox = null;
                atual = ultimo;
            }
            else  // caso geral, nó interno sendo excluído
            {
                anterior.Prox = atual.Prox;
                atual = atual.Prox;
            }

            quantosNos--;
            return true;  // conseguiu excluir
        }

        return false;
    }

    public void InserirAntesDoInicio(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            ultimo = novoNo;

        novoNo.Prox = primeiro;
        primeiro = novoNo;
        quantosNos++;
    }

    public void InserirAposFim(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        ultimo = novoNo;
        quantosNos++;
    }

    public void Listar(ListBox lsb)
    {
        lsb.Items.Clear();
        atual = primeiro;
        while (atual != null)
        {
            lsb.Items.Add(atual.Info);
            atual = atual.Prox;
        }
    }
}
