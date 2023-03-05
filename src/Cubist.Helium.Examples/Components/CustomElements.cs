using System.ComponentModel;
using static Cubist.Helium.He;
using static Cubist.Helium.Examples.Components.TodoListComponent;

namespace Cubist.Helium.Examples.Components
{
    [Description("Shows how to integrate your custom elements with Helium")]
    public class CustomElements : IExample
    {
        private readonly Todo[] _todoList = new[]
        {
            new Todo(Description: "Add javascript", Status: "New"),
            new Todo(Description: "Add styling", Status: "New"),
            new Todo(Description: "Add template", Status: "Done"),
            new Todo(Description: "Make component element example", Status: "Done"),
        };

        public Node Render()
            => Document(
                Head(
                    Script(
                        DefineCustomElement(TodoListElement, TodoListTemplateId),
                        DefineCustomElement(TodoItemElement, TodoItemTemplateId))),
                Body(
                    TodoListTemplate(),
                    TodoItemTemplate(),
                    TodoList(_todoList)));

    }
}
