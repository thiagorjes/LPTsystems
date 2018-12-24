using System;
using System.Collections.Generic;
using System.Linq;
using LPT.Interfaces;
using LPT.Models;

namespace LPT.Services
{
    public class ExperimentoRepository : IGenericRepository
    {
        private LPTContext context;
        private List<Experimento> _all;
        public ExperimentoRepository(LPTContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(LPTContext ctx)
        {
            context = ctx;
            _all = context.Experimento.ToList();
        }
        IEnumerable<object> IGenericRepository.All
        {
            get
            {
                return _all;
            }
        }
        public object Create(object p){
            try
            {
                /**
                    Posteriormente, sempre que um novo experimento for criado, todos os experimentos com dataFim em branco serão "settados" para "now()"
                    Desta forma evitamos que mais de um experimento fique "ativo"
                 */
                Experimento r = (context.Experimento.Add((Experimento)p)).Entity;
                context.SaveChanges();
                Program.experimentoAtivo = r.IdExperimento;
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int IdExperimento){
            try
            {
                Experimento r = (from p in context.Experimento where p.IdExperimento==IdExperimento select p).FirstOrDefault<Experimento>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int IdExperimento,object newObject ){
            try
            {
                Experimento r = (from p in context.Experimento where p.IdExperimento==IdExperimento select p).FirstOrDefault<Experimento>();
                foreach(var att in ((Experimento) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("IdExperimento"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
                }
                context.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string Delete(int IdExperimento){
            try
            {
                var r = (from p in context.Experimento where p.IdExperimento==IdExperimento select p).FirstOrDefault<Experimento>();
                var listaDados = (from p in context.DadoColetado where p.Experimento == IdExperimento select p);
                var listaMedidores = (from p in context.MedidorExperimento where p.Experimento == IdExperimento select p);
                context.MedidorExperimento.RemoveRange(listaMedidores);
                context.DadoColetado.RemoveRange(listaDados);
                context.Experimento.Remove(r);
                context.SaveChanges();
                return "Experimento removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover Experimento!";
            }
        }
        public List<object> ReadManyByParam(DateTime DataInicio){
            try
            {
                List<object> r = (from p in context.Experimento where p.DataInicio==DataInicio select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<object> ExperimentoAll(){
        return _all.ToList<object>();
        }
    }
}