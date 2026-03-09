import Heading from './components/Heading';
import BowlerTable from './components/BowlerTable';
import './App.css';

// App component - the root component of the application
// Combines the Heading and BowlerTable components to display the full page
function App() {
  return (
    <div className="app-container">
      {/* Heading component describes the purpose of the page */}
      <Heading />
      {/* BowlerTable component fetches and displays bowler data */}
      <BowlerTable />
    </div>
  );
}

export default App;
