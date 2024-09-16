using System;
using System.Windows.Forms;

//, ICriterioDeSeparacao<Dado>

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

    public NoLista<Dado> Atual => atual;

    public NoLista<Dado> Ultimo
    {
        get => ultimo;
    }
    public int QuantosNos
    {
        get => quantosNos;
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
