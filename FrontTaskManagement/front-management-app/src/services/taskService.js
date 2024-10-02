import api from '../utils/api';

export const getTasks = async () => {
  const response = await api.get('/api/tasks');
  return response.data;
};

export const createTask = async (task) => {
  const response = await api.post('/api/tasks', task);
  return response.data;
};

export const listState = async()=>{
  const response = await api.get('/api/states');
  return response.data;
}

export const updateTask = async (id, task) => {
  const response = await api.put(`/api/tasks/${id}`, task);
  return response.data;
};

export const deleteTask = async (id) => {
  await api.delete(`/api/tasks/${id}`);
};
