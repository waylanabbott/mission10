// Heading component - displays the page title and description
// Used at the top of the App component to describe the purpose of the page
function Heading() {
  return (
    <header className="page-header">
      <h1>Bowling League - Team Roster</h1>
      <p>
        Bowler information for the Marlins and Sharks teams.
      </p>
    </header>
  );
}

export default Heading;
