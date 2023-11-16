import './css/layout.css';
import logo from './Showcase RV Hub.png'
import logo2 from './Showcase RV Hub.webp'
import Form from './Form';

function Layout() {



  return <>
  <div className="App">      
      <div className="App-header">
        <div className='h1-div'>
          <h1 className="title">Reset User's Password</h1>
        </div>
        <div className='img-div'>
          <img src={logo2} alt="Showcase" className="logo" /> 
        </div>           
        <div className='form-div'> 
        <Form/>      
      </div>      
      </div>   
      <footer className='footer'>
        <p> Powered by{' '} Showcase RV Hub </p>
        <a href='https://www.showcaservhub.com' target='_blank' rel='noreferrer'>
          <img  src={logo} alt="Showcase" className="footlogo" />
        </a>
      </footer>
    </div>
  </>
}

export default Layout