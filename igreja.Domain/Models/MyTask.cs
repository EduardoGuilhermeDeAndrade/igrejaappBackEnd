//using igreja.Domain.Models.Enums;
//using igreja.Domain.Models.General;

//namespace igreja.Domain.Models
//{
//    public class MyTask : EntityTenantUser
//    {
//        public MyTask() { 
//            Tags = new List<string>(); 
//        }

//        public string Title { get; set; } = string.Empty;
//        public string Description { get; set; } = string.Empty;
//        public EnumStatusTask Status { get; set; } = EnumStatusTask.Pendente;
//        public EnumPriorityTask Priority { get; set; } = EnumPriorityTask.Média;
//        public EnumCategoryTask Categoria { get; set; }

//        public List<string> Tags { get; set; }

//        public DateTime CompletionDate { get; set; } //Data de conclusão
//        public DateTime DeadlineInDate { get; set; } //Data limite
//        public Guid ResponsableId { get; set; } //Responsável pela tarefa, somente quem está liberado como responsavel por tarefas no banco

//        // Propriedades de navegação
//        public Guid UserResponsableId { get; set; } 
//        public User UserResponsable { get; set; }

//        //Os anexos são tratados fora do domíno

        
//    }
//}
