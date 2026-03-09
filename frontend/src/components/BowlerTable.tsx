import { useState, useEffect } from 'react';
import type { Bowler } from '../types/Bowler';

// BowlerTable component - fetches and displays bowler data in a table
// Data is fetched from the ASP.NET API at /api/bowlers
function BowlerTable() {
  // State for storing the list of bowlers from the API
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  // State for tracking loading status
  const [loading, setLoading] = useState<boolean>(true);
  // State for storing any error messages
  const [error, setError] = useState<string | null>(null);

  // Fetch bowler data from the API when the component mounts
  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        // Call the ASP.NET API endpoint (proxied through Vite)
        const response = await fetch('/api/bowlers');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        // Parse the JSON response into an array of Bowler objects
        const data: Bowler[] = await response.json();
        setBowlers(data);
      } catch (err) {
        setError(
          err instanceof Error ? err.message : 'Failed to fetch bowlers'
        );
      } finally {
        setLoading(false);
      }
    };

    fetchBowlers();
  }, []); // Empty dependency array ensures this runs only once on mount

  // Show loading message while data is being fetched
  if (loading) return <p>Loading bowlers...</p>;
  // Show error message if the fetch failed
  if (error) return <p>Error: {error}</p>;

  // Render the bowler data in a styled table
  return (
    <table className="bowler-table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {/* Map over each bowler and create a table row */}
        {bowlers.map((b) => (
          <tr key={b.bowlerID}>
            {/* Format name: "First M. Last" or "First Last" if no middle initial */}
            <td>
              {b.bowlerFirstName}
              {b.bowlerMiddleInit ? ` ${b.bowlerMiddleInit}.` : ''}{' '}
              {b.bowlerLastName}
            </td>
            <td>{b.teamName}</td>
            <td>{b.bowlerAddress}</td>
            <td>{b.bowlerCity}</td>
            <td>{b.bowlerState}</td>
            <td>{b.bowlerZip}</td>
            <td>{b.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerTable;
