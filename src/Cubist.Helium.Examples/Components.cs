using System.ComponentModel;
using static Cubist.Helium.He;

namespace Cubist.Helium.Examples
{
    [Description("Shows how to integrate your custom elements with Helium")]
    public static class Components
    {

        [Example("Render a todo list using custom elements")]
        public static Node TodoList()
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

        private static He TodoList(IReadOnlyList<Todo> list)
        {
            var activeCount = list.Count(x => x.Status != "done");
            return Custom(TodoListElement,
                // insert the item count into the count slot
                Div(("slot", TodoListItemCountSlotId),
                    Data(activeCount, $"{activeCount} of {list.Count} items to go")),
                // the rest of the contents go into the unnamed slot
                list.Select(TodoItem));
        }

        private static He TodoItem(Todo todo)
            => Custom(TodoItemElement,
                // add the status in the status attribute
                (TodoItemStatusAttr, todo.Status),
                // the rest goes in the unnamed slot
                todo.Description);

        private static He TodoListTemplate() =>
            Template(TodoListTemplateId,
                // some simple styling for the list template.
                Style(
                    Css("ul",
                        ("display", "grid"),
                        ("grid", "auto-flow / 1fr"),
                        ("row-gap", "1em"),
                        ("list-style-type", "none"),
                        ("background-color", "silver"),
                        ("border-radius", "1em"),
                        ("padding", "1em"))),
                // the template itself.
                Div(("class", TodoListElement),
                    Div(("class", "todo-list-status"),
                        Slot(TodoListItemCountSlotId) /* named item count slot */),
                    Div(("class", "todo-list-items"),
                        Ul(
                            Slot() /* unnamed slot, receives all custom element content not inserted into a named slot.*/))));

        private static He TodoItemTemplate() =>
            Template(TodoItemTemplateId,
                // some simple styling for the item template.
                Style(
                    Css(":host",
                        ("border", "2px solid black"),
                        ("border-radius", "1em"),
                        ("padding", "1em")),
                    Css(":host(.new)",
                        ("background-color", "white")),
                    Css(":host(.done)",
                        ("background-color", "silver"),
                        ("text-decoration", "line-through"))),
                // the template itself.
                Li(("class", TodoItemElement),
                    (TodoItemStatusAttr, "new"),
                    Div(("class", "item-description"),
                        Slot() /* unnamed slot, receives all custom element content not inserted into a named slot.*/)));


        /// <summary> A simple to-do item model. </summary>
        private record Todo(string Status, string Description);

        /// <summary> the list of to-do items to render. </summary>
        private static readonly Todo[] _todoList = new[]
        {
            new Todo(Description: "Add toggle button", Status: "new"),
            new Todo(Description: "Improve styling", Status: "new"),
            new Todo(Description: "Add template", Status: "done"),
            new Todo(Description: "Make component element example", Status: "done"),
        };

        // constants for all the ids and names that tie templates and custom elements together. 

        private const string TodoListElement = "todo-list";
        private const string TodoListTemplateId = "todo-list-template";
        private const string TodoListItemCountSlotId = "todo-list-item-count";

        private const string TodoItemElement = "todo-item";
        private const string TodoItemTemplateId = "todo-item-template";
        private const string TodoItemStatusAttr = "status";

        /// <summary>
        /// Adds a status attribute, that toggles the to-do item element class
        /// So the rendering changes
        /// </summary>
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
}
