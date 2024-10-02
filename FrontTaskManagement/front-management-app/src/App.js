import React from 'react';
import { BrowserRouter as Router, Route, Routes, NavLink , Navigate} from 'react-router-dom';
import TaskPage from './pages/TaskPage';
import StatePage from './pages/StatePage';
import './App.css';

const App = () => {
  return (
    <Router>
      <div className="container">
        <nav>
          <ul>
            <li>
              <NavLink to="/tasks" className={({ isActive }) => isActive ? "activo" : ""}>
                Ver Tareas
              </NavLink>
            </li>
            <li>
              <NavLink to="/states" className={({ isActive }) => isActive ? "activo" : ""}>
                Ver Estados
              </NavLink>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<Navigate to="/tasks" replace />} />
          <Route path="/tasks" element={<TaskPage />} />
          <Route path="/states" element={<StatePage />} />
          <Route path="*" element={<Navigate to="/tasks" replace />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;

