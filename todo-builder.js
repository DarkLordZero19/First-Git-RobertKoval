document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('todo-builder-form');
    const container = document.getElementById('todo-list-container');
  
    // Load saved parameters from localStorage
    loadSavedParameters();
  
    form.addEventListener('submit', (event) => {
      event.preventDefault();
  
      // Get form data
      const formData = new FormData(event.target);
      const parameters = {
        maxTasks: formData.get('max-tasks'),
        daysPerWeek: formData.get('days-per-week'),
        language: formData.get('language')
      };
  
      // Generate Todo List
      generateTodoList(parameters, container);
  
      // Save parameters to localStorage
      saveTodoParameters(parameters);
    });
  });
  
  function loadSavedParameters() {
    // Load saved parameters from localStorage
    const savedParameters = JSON.parse(localStorage.getItem('todoParameters'));
    if (savedParameters) {
      document.getElementById('max-tasks').value = savedParameters.maxTasks;
      document.getElementById('days-per-week').value = savedParameters.daysPerWeek;
      document.getElementById('language').value = savedParameters.language;
    }
  }
  
  function saveTodoParameters(parameters) {
    // Save parameters to localStorage
    localStorage.setItem('todoParameters', JSON.stringify(parameters));
  }
  
  function generateTodoList(parameters, container) {
    // Generate Todo List table based on the provided parameters
    const { maxTasks, daysPerWeek, language } = parameters;
    const table = document.createElement('table');
    const tableBody = document.createElement('tbody');
  
    // Create table header
    const headerRow = document.createElement('tr');
    headerRow.innerHTML = `
      <th>Day</th>
      ${Array.from({ length: maxTasks }, (_, index) => `<th>Task ${index + 1}</th>`).join('')}
    `;
    tableBody.appendChild(headerRow);
  
    // Generate table rows
    for (let day = 1; day <= daysPerWeek; day++) {
      const row = document.createElement('tr');
      row.innerHTML = `
        <td>Day ${day}</td>
        ${Array.from({ length: maxTasks }, () => '<td></td>').join('')}
      `;
      tableBody.appendChild(row);
    }
  
    table.appendChild(tableBody);
    container.innerHTML = '';
    container.appendChild(table);
  }