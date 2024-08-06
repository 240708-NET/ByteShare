import Header from "../components/Header";



export default function Home() {

  return(
    <main>
      <Header></Header>
        <div className="about-us-container">
            <div className="header">
                <h1>Byte<span>Share</span> DevTeam</h1>
                <p>Meet the team behind our project</p>
            </div>

            <div className="developers">
                <div className="developer">
                    <img src="../images/BowlLogo.png" alt="Developer 1"/>
                    <h3>Bilal Mirza</h3>
                    <p>Title</p>
                </div>
                <div className="developer">
                    <img src="../images/BowlLogo.png" alt="Developer 2"/>
                    <h3>Bremer Jonathan</h3>
                    <p>Title</p>
                </div>
                <div className="developer">
                    <img src="../images/BowlLogo.png" alt="Developer 3"/>
                    <h3>Tamekia Nelson</h3>
                    <p>Title</p>
                </div>
                <div className="developer">
                    <img src="../images/BowlLogo.png" alt="Developer 4"/>
                    <h3>Robert Tan Huynh</h3>
                    <p>Title</p>
                </div>
            </div>
        </div>
    </main>
  );
}