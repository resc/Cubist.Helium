using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Components;

public static class TodoListComponent
{

    public const string TodoListElement = "todo-list";
    public const string TodoListTemplateId = "todo-list-template";
    public const string TodoListItemCountSlotId = "todo-list-item-count"; 

    public const string TodoItemElement = "todo-item";
    public const string TodoItemTemplateId = "todo-item-template";
    public const string TodoItemStatusSlotId = "todo-item-status"; 

    public static He TodoListTemplate() =>
        Template(TodoListTemplateId,
            Div(("class", TodoListElement),
                Div(("class", "todo-list-status"), Slot(TodoListItemCountSlotId)),
                Div(("class", "todo-list-items"), Ul(Slot()))));


    public static He TodoItemTemplate() => Template(TodoItemTemplateId,
        Li(("class", TodoItemElement),
            Div(("class", "item-status"), Slot(TodoItemStatusSlotId)),
            Div(("class", "item-description"), Slot())));

    public static He TodoList(IReadOnlyList<Todo> list)
    {
        var activeCount = list.Count(x => x.Status != "Done");
        return
            Custom(TodoListElement,
                Div(("slot", TodoListItemCountSlotId),
                    Data(activeCount, $"{activeCount} of {list.Count} items to go")),
                list.Select(TodoItem));
    }

    public static He TodoItem(Todo todo)
        => Custom(TodoItemElement,
            Span(("slot", TodoItemStatusSlotId), todo.Status),
            todo.Description);
}