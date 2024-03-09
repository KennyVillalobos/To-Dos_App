namespace To_Dos_App.API.DTO
{
    public class ToDoTaskDTOResponse
    {
        public Guid Id { get; set; }
        public string CreationDateTime { get; set; }
        public string TaskMessage { get; set; }
        public bool Completed { get; set; }
        public string FinishDate { get; set; }
    }
}
