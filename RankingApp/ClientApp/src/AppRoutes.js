import { Counter } from "./components/Counter";
import { Home } from "./components/Home";
import FetchGridData from "./components/FetchGridData";


const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchGridData />
    },
];

export default AppRoutes;
