using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoDIO.Context;
using ProjetoDIO.Models;

namespace ProjetoDIO.Controllers
{

    public class TarefaController : Controller

    {
        
        private readonly TarefaContext _tarefa;

        public TarefaController(TarefaContext tarefa){
            _tarefa = tarefa;
        }

        public IActionResult Index(){

            var tarefas = _tarefa.tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult CriarTarefa(){

            return View();
        }
       [HttpPost]
       public IActionResult CriarTarefa(Tarefa tarefa){

            if(ModelState.IsValid){
                _tarefa.tarefas.Add(tarefa);
                _tarefa.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(tarefa);
        }
        
        public IActionResult EditarTarefa( int id){

            var tarefa = _tarefa.tarefas.Find(id);

            if(tarefa == null)
            return RedirectToAction(nameof(Index));

            return View(tarefa);

        }
         [HttpPost]
        public IActionResult EditarTarefa(Tarefa tarefa) {

            var editandoTarefa = _tarefa.tarefas.Find(tarefa.Id);

            editandoTarefa.Titulo = tarefa.Titulo;
            editandoTarefa.Data = tarefa.Data;
            editandoTarefa.Descricao = tarefa.Descricao;
            editandoTarefa.Status = tarefa.Status;

            _tarefa.tarefas.Update(editandoTarefa);
            _tarefa.SaveChanges();


            return RedirectToAction(nameof(Index));

        }

        public IActionResult DetalhesTarefa(int id){

            var tarefa = _tarefa.tarefas.Find(id);

            if(tarefa == null)
            return RedirectToAction(nameof(Index));

            return View(tarefa);
        }

        public IActionResult DeletarTarefa(int id){

            var tarefa = _tarefa.tarefas.Find(id);

            if(tarefa == null)
              return  RedirectToAction(nameof(Index));

              return View(tarefa);
        }
         [HttpPost]
        public IActionResult DeletarTarefa(Tarefa tarefa){

            var deletarTarefaDoBanco = _tarefa.tarefas.Find(tarefa.Id);

            _tarefa.tarefas.Remove(deletarTarefaDoBanco);
            _tarefa.SaveChanges();
            
            return  RedirectToAction(nameof(Index));

        }

       

        
      }
}