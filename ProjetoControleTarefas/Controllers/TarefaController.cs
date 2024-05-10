using Microsoft.AspNetCore.Mvc;
using ProjetoControleTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class TarefaController : Controller
{
    private static List<Tarefa> _tarefas = new List<Tarefa>();

    // Exibir tarefas por fazer
    public IActionResult PorFazer()
    {
        var porFazer = _tarefas.Where(t => !t.Concluida).ToList();
        return View(porFazer);
    }

    // Exibir tarefas feitas
    public IActionResult Feitas()
    {
        var feitas = _tarefas.Where(t => t.Concluida).ToList();
        return View(feitas);
    }

    // Adicionar nova tarefa
    [HttpGet]
    public IActionResult Adicionar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Adicionar(Tarefa tarefa)
    {
        tarefa.Id = _tarefas.Count + 1;
        tarefa.DataInicio = DateTime.Now;
        _tarefas.Add(tarefa);
        return RedirectToAction("PorFazer");
    }

    // Marcar tarefa como concluída
    public IActionResult Concluir(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa != null)
        {
            tarefa.DataConclusao = DateTime.Now;
        }
        return RedirectToAction("PorFazer");
    }

    // Excluir tarefa
    public IActionResult Excluir(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa != null)
        {
            _tarefas.Remove(tarefa);
        }
        return RedirectToAction("PorFazer");
    }

    public IActionResult TarefasEmAndamento()
    {
        return View(_tarefas);
    }

}
