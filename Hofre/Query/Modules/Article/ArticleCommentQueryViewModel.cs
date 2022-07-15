namespace Query.Modules.Article
{
    public class ArticleCommentQueryViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; }
        public string UserProfile { get; set; }
        public string UserRole { get; set; }
        public string CreationDate { get; set; }
    }
}