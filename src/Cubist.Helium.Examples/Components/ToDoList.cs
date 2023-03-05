using System.ComponentModel;
using static Cubist.Helium.He;
using static Cubist.Helium.Examples.Components.TodoListComponent;

namespace Cubist.Helium.Examples.Components
{
    [Description("Shows how to integrate your custom elements with Helium")]
    public class ToDoList : IExample
    {
        private readonly Todo[] _todoList = new[]
        {
            new Todo(Description: "Add toggle button", Status: "new"),
            new Todo(Description: "Improve styling", Status: "new"),
            new Todo(Description: "Add template", Status: "done"),
            new Todo(Description: "Make component element example", Status: "done"),
        };


        public Node Render()
            => Document(
                Head(
                    Script(
                        // the list is simple
                        DefineCustomElement(TodoListElement, TodoListTemplateId),
                        // the to do item element add an attributeChangedCallback
                        // see https://googlechromelabs.github.io/howto-components/howto-checkbox/#demo for inspiration.
                        TodoItemDefinitionScript)),
                Body(
                    TodoListTemplate(),
                    TodoItemTemplate(),
                    TodoList(_todoList)));

    }
}
