import './App.css';
import Form from './components/Form';

function App() {
  return (
    <div className="App">
      <header className="App-header">
      <h1 className="title">
          Reset User's Password
        </h1>
        <div>
        <Form/>
      </div>
      </header>
      
      <footer>
        <a>
          Powered by{' '} Showcase RV Hub
          <img src="/Showcase RV Hub.webp" alt="Showcase" className="logo" />
        </a>
      </footer>
    </div>
  );
}

export default App;
