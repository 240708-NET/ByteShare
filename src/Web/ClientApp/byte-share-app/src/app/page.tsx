import HomePage from './pages/Home'
import MyRecipes from './pages/MyRecipes'
import AllRecipes from './pages/AllRecipes'
import About from './pages/About'



export default function Home() {

  return ( 
    <div>
        <HomePage/>
        <About/>
        <MyRecipes/>
        <AllRecipes/>
    </div>

  );
}
