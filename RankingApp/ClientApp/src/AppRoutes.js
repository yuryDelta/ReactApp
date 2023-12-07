import DisplayGrid from "./components/DisplayGrid";
import { Home } from "./components/Home";


const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/displaygrid',
        element: <DisplayGrid />
    }
];

export default AppRoutes;
