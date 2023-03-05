using static Cubist.Helium.He;

namespace Cubist.Helium.Examples.Components;

public static class TodoListComponent
{
    // constants for all the ids and names that
    // tie templates and custom elements together. 

    public const string TodoListElement = "todo-list";
    public const string TodoListTemplateId = "todo-list-template";
    public const string TodoListItemCountSlotId = "todo-list-item-count"; 

    public const string TodoItemElement = "todo-item";
    public const string TodoItemTemplateId = "todo-item-template";
    public const string TodoItemStatusAttr = "status"; 

    public static He TodoListTemplate() =>
        Template(TodoListTemplateId,
            // some simple styling for the list template.
            Style($"ul {{ display: grid; grid: auto-flow / 1fr; row-gap: 1em; " +
                  $"list-style-type: none; background-color: silver; border-radius: 1em; padding: 1em;   }}"),
            // the template itself.
            Div(("class", TodoListElement),
                Div(("class", "todo-list-status"), Slot(TodoListItemCountSlotId)/* named item count slot */),
                Div(("class", "todo-list-items"), Ul(Slot()/* unnamed slot, receives all custom element content not inserted into a named slot.*/))));


    public static He TodoItemTemplate() =>
        Template(TodoItemTemplateId,
            // some simple styling for the item template.
            Style($":host {{ border: 2px solid black; border-radius: 1em; padding: 1em; }}\n" ,
                  ":host(.new) { background-color: white;  }\n",
                  ":host(.done) { background-color: silver; text-decoration: line-through; }\n"
                ),
            // the template itself.
            Li(("class", TodoItemElement),
                (TodoItemStatusAttr,"new"), 
                Div(("class", "item-description"), Slot()/* unnamed slot, receives all custom element content not inserted into a named slot.*/)));

    public static He TodoList(IReadOnlyList<Todo> list)
    {
        var activeCount = list.Count(x => x.Status != "done");
        return Custom(TodoListElement,
            // insert the item count into the count slot
            Div(("slot", TodoListItemCountSlotId),
                Data(activeCount, $"{activeCount} of {list.Count} items to go")),
            // the rest of the contents go into the unnamed slot
            list.Select(TodoItem));
    }

    public static He TodoItem(Todo todo)
        => Custom(TodoItemElement,
            // add the status in the status attribute
            (TodoItemStatusAttr, todo.Status), 
            // the rest goes in the unnamed slot
            todo.Description);

    
    public static readonly string TodoItemDefinitionScript = $@"customElements.define(
  ""{TodoItemElement}"",
  class extends HTMLElement {{

    static get observedAttributes() {{
      return ['{TodoItemStatusAttr}'];
    }}

    constructor() {{
      super();
      let template = document.getElementById(""{TodoItemTemplateId}"");
      let templateContent = template.content;

      const shadowRoot = this.attachShadow({{ mode: ""open"" }});
      const clone = templateContent.cloneNode(true);
      shadowRoot.appendChild(clone);
    }}
    
    connectedCallback() {{
        if (!this.hasAttribute('{TodoItemStatusAttr}'))
           this.setAttribute('{TodoItemStatusAttr}', 'new');

        this._upgradeProperty('{TodoItemStatusAttr}');
    }}

    attributeChangedCallback(name, oldValue, newValue) {{
        console.log(""{TodoItemElement} "" + name + "" changed from '"" + oldValue + ""' to '"" + newValue + ""'"");
        if (name === '{TodoItemStatusAttr}') {{
            this.classList.remove(oldValue);
            this.classList.add(newValue);
        }}
    }}

    _upgradeProperty(prop) {{
      if (this.hasOwnProperty(prop)) {{
        let value = this[prop];
        delete this[prop];
        this[prop] = value;
      }}
    }}

    set {TodoItemStatusAttr}(value) {{       
        this.setAttribute('{TodoItemStatusAttr}', value);      
    }}

    get {TodoItemStatusAttr}() {{
      return this.getAttribute('{TodoItemStatusAttr}');
    }}
  }});
";
}