import useFetchHouses from "../hooks/HouseHooks";
import { House } from "../types/House";
import { currencyFormatter } from "../config";
import ApiStatus from "../apiStatus";
import { Link } from "react-router-dom";
import defaultPhoto from "./defaultPhoto";

const HouseList=() =>{
    const {data,status,isSuccess} = useFetchHouses();
    if(!isSuccess)
        return <ApiStatus status={status} />;
    return (
      <div>
        <div className="page-head">
          <div>
            <h1>Houses on the market</h1>
            <p>
              {data?.length ?? 0} {data?.length === 1 ? "home" : "homes"} for sale
            </p>
          </div>
          <Link className="btn btn-primary" to="/house/add">
            Add a house
          </Link>
        </div>
        {data && data.length > 0 ? (
          <div className="listing-grid">
            {data.map((h: House) => (
              <Link key={h.id} className="listing" to={`/house/${h.id}`}>
                <img
                  className="listing__photo"
                  src={h.photo ? h.photo : defaultPhoto}
                  alt=""
                  loading="lazy"
                />
                <div className="listing__body">
                  <h2 className="listing__address">{h.address}</h2>
                  <span className="listing__country">{h.country}</span>
                  <span className="listing__price">
                    {currencyFormatter.format(h.price)}
                  </span>
                </div>
              </Link>
            ))}
          </div>
        ) : (
          <div className="empty-state">
            <h2 className="h4">No houses listed yet</h2>
            <p>Add the first house to start receiving bids.</p>
            <Link className="btn btn-primary" to="/house/add">
              Add a house
            </Link>
          </div>
        )}
      </div>
    );
};
export default HouseList;
