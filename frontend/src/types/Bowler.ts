// TypeScript interface defining the shape of a Bowler object
// Property names are camelCase to match ASP.NET Core's default JSON serialization
export interface Bowler {
  bowlerID: number;
  bowlerFirstName: string;
  bowlerMiddleInit: string | null; // Middle initial can be null
  bowlerLastName: string;
  teamName: string; // Joined from the Teams table
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
}
