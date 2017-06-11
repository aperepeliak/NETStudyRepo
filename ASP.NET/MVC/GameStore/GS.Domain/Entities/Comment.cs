namespace GS.Domain.Entities
{
    public class Comment
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public string GameId { get; set; }
        public int? ParentCommentId { get; set; }

        public Game Game { get; set; }
        public Comment ParentComment { get; set; }
    }
}
