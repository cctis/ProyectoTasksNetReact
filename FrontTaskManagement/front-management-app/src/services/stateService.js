import api from '../utils/api';

// Obtener la lista de estados
export const getStates = async () => {
  const response = await api.get('/api/states');
  return response.data;
};

// Crear un nuevo estado
export const createState = async (state) => {
  const response = await api.post('/api/states', state);
  return response.data;
};

// Actualizar un estado existente
export const updateState = async (id, state) => {
  const response = await api.put(`/api/states/${id}`, state);
  return response.data;
};

// Eliminar un estado existente
export const deleteState = async (id) => {
  await api.delete(`/api/states/${id}`);
};
