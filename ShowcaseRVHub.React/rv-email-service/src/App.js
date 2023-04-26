import './App.css';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Layout from './components/Layout'
import Success from './components/success';

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Layout/>} />
        <Route path='/success' element={<Success />} />
      </Routes>
    </Router>
  );
}

export default App;
