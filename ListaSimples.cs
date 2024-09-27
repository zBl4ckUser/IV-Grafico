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

    //Versão de ExisteDado da apostila alterado para que funcione com Listas desordenadas
    public bool ExisteDado(Dado procurado)
    {
        // anterior e atual definirão a região onde o dado pode estar
        anterior = atual = null;
        if (EstaVazia)
            return false;

        // percorre a lista desde o início
        atual = primeiro;
        bool achou = false;

        // percorremos a lista enquanto atual não for nulo
        while (atual != null && !achou)
        {
            // se encontramos o Dado procurado
            if (atual.Info.CompareTo(procurado) == 0)
                achou = true;
            else
            {
                // avançamos os ponteiros
                anterior = atual;
                atual = atual.Prox;
            }
        }

        // retorna se encontramos o dado
        return achou;
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
