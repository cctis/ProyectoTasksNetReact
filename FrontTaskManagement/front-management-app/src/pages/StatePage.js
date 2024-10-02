import React, { useState, useEffect } from 'react';
import { getStates, createState, updateState, deleteState } from '../services/stateService';
import './StatePage.css'; 

const StatePage = () => {

  const [states, setStates] = useState([]);
  const [state, setState] = useState({ id: null, stateName: '' });
  
  const [editingStateId, setEditingStateId] = useState(null);
  const [loading, setLoading] = useState(true); 

  // Se Carga los estados desde el servicio al montar el componente
  const loadStates = async () => {
    const data = await getStates();
    setStates(data);
    setLoading(false); // Se cambia el estado de carga a falso una vez que se ha cargado los estados
  };

  useEffect(() => {
    loadStates();
  }, []);

  // envío el formulario
  const handleSubmit = async (e) => {
    e.preventDefault();
    const stateData = { stateName: state.stateName }; // el nombre del estado

    if (editingStateId) {
      await updateState(editingStateId, stateData);
      setEditingStateId(null);
    } else {
      await createState(stateData);
    }

    setState({ id: null, stateName: '' }); // Reiniciar el formulario
    loadStates(); // Recargar los estados
  };

  // eliminación de estado
  const handleDelete = async (id) => {
    await deleteState(id);
    loadStates();
  };

  // edición de estado
  const handleEdit = (stateToEdit) => {
    setEditingStateId(stateToEdit.id);
    setState({ id: stateToEdit.id, stateName: stateToEdit.stateName }); // Cargar el estado para editar
  };

  return (
    <div className="state-page-container">
      <h2>Gestión de Estados</h2>
      <form onSubmit={handleSubmit} className="state-form">
        <input
          type="text"
          value={state.stateName}
          onChange={(e) => setState({ ...state, stateName: e.target.value })}
          placeholder="Nombre del estado"
          required
          className="state-input"
        />
        <button type="submit" className="state-button">
          {editingStateId ? 'Actualizar' : 'Crear'}
        </button>
      </form>

      <h3>Lista de Estados</h3>
      <ul className="state-list">
        {states.length > 0 ? (
          states.map((state) => (
            <li key={state.id} className="state-item">
              {state.stateName} 
              <div className="state-actions">
                <button onClick={() => handleEdit(state)} className="state-edit-button">
                  Editar
                </button>
                <button onClick={() => handleDelete(state.id)} className="state-delete-button">
                  Eliminar
                </button>
              </div>
            </li>
          ))
        ) : (
          <p>No hay estados disponibles.</p>
        )}
      </ul>
    </div>
  );
};

export default StatePage;
