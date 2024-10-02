import React, { useState, useEffect } from 'react';
import { getTasks, createTask, updateTask, deleteTask,listState } from '../services/taskService';

import './TaskPage.css'; 

const TaskPage = () => {

  const [tasks, setTasks] = useState([]);
  const [title, setTitle] = useState('');
  
  const [stateId, setStateId] = useState(''); // estado para el ID del estado
  const [editingTaskId, setEditingTaskId] = useState(null);
  
  const [states, setStates] = useState([]); 
  const [loading, setLoading] = useState(true); // Estado de carga para los estados

  
  const loadTasks = async () => {
    const data = await getTasks();
    setTasks(data);
  };

  // cargar estados desde el servicio
  const loadStates = async () => {
    const data = await listState();
    setStates(data);
    setLoading(false); 
  };

  useEffect(() => {
    loadTasks();
    loadStates();
  }, []);

  // Manejar el envío del formulario
  const handleSubmit = async (e) => {
    e.preventDefault();
    const taskData = { title, stateId }; 

    if (editingTaskId) {
      await updateTask(editingTaskId, taskData);
      setEditingTaskId(null);
    } else {
      await createTask(taskData);
    }
    setTitle('');
    setStateId(''); // Limpiar el campo de ID del estado
    loadTasks();
  };

  // eliminación de una tarea
  const handleDelete = async (id) => {
    await deleteTask(id);
    loadTasks();
  };

  // edición de una tarea
  const handleEdit = (task) => {
    setEditingTaskId(task.id);
    setTitle(task.title);
    setStateId(task.stateId); // estado actual al editar
  };

  return (
    <div className="task-page-container">
      <h2>Gestión de Tareas</h2>
      <form onSubmit={handleSubmit} className="task-form">
        <input
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          placeholder="Título de la tarea"
          required
          className="task-input"
        />
        <select
          value={stateId}
          onChange={(e) => setStateId(e.target.value)}
          required
          className="task-select"
        >
          <option value="">Seleccionar estado</option>
          {!loading && states.map((state) => (
            <option key={state.id} value={state.id}>
              {state.stateName}
            </option>
          ))}
        </select>
        <button type="submit" className="task-button">
          {editingTaskId ? 'Actualizar' : 'Crear'}
        </button>
      </form>

      <h3>Lista de Tareas</h3>
      <ul className="task-list">
        {tasks.length > 0 ? (
            tasks.map((task) => (
              <li key={task.id} className="task-item">
                {task.title} - <span className="task-state-label">Estado:</span> {task.state.stateName} 
                <div className="task-actions">
                  <button onClick={() => handleEdit(task)} className="task-edit-button">
                    Editar
                  </button>
                  <button onClick={() => handleDelete(task.id)} className="task-delete-button">
                    Eliminar
                  </button>
                </div>
              </li>
            ))
          ) : (
            <p>No hay tareas disponibles.</p>
          )}
        </ul>
    </div>
  );
};

export default TaskPage;
