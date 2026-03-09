import { useState, useEffect } from 'react';
import type { Bowler } from '../types/Bowler';

function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch('/api/bowlers');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
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
  }, []);

  if (loading) return <p>Loading bowlers...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <table>
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
        {bowlers.map((b) => (
          <tr key={b.bowlerID}>
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
