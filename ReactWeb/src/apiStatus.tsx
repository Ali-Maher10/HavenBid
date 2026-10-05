type Args={
    status:"success" | "error" | "pending";
};

const ApiStatus=({status}:Args)=>{
    switch(status){
        case "error":
            return (
                <section className="api-status api-status--error" role="alert">
                    <div className="api-status__icon" aria-hidden="true">!</div>
                    <div className="api-status__copy">
                        <h2>Couldn’t load the data</h2>
                        <p>The server didn’t respond. Check that the API is running, then reload the page.</p>
                    </div>
                </section>
            );
        case "pending":
            return (
                <section className="api-status api-status--pending" role="status" aria-live="polite">
                    <div className="api-status__loader" aria-hidden="true">
                        <span />
                    </div>
                    <div className="api-status__copy">
                        <h2>Loading</h2>
                        <p>Fetching the latest data.</p>
                    </div>
                    <div className="api-status__track" aria-hidden="true"><span /></div>
                </section>
            );
        case "success":
            return null;
    }
};

export default ApiStatus;