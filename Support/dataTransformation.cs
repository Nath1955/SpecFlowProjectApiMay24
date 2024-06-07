namespace SpecFlowProjectApiMay24.Support
{
    [Binding]
    public class dataTransformation
    {
        [StepArgumentTransformation]
        public TableModel TableData(Table table)
        {
            return table.CreateInstance<TableModel>();
        }

        [StepArgumentTransformation]
        public IEnumerable<TableModel> TableDataList(Table table)
        {
            return table.CreateSet<TableModel>().ToList();
        }

        [StepArgumentTransformation]
        public CreateNewRequestUserModel NewUser(Table table) 
        {
            return table.CreateInstance<CreateNewRequestUserModel>();
        }

    }
}
